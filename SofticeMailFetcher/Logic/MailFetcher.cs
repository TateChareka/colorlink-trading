using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Configuration;
using HtmlAgilityPack;


namespace SofticeMailFetcher
{
    public static class MailFetcher
    {
        private static Chilkat.Imap imap;

        private static bool IMAPConnection(IMAPConnectionRequestModel request)
        {
            bool success = false;
            try
            {
                int serverPort = request.ServerPort;
                string serverName = request.ServerName;
                string emailAddress = request.EmailAddress;
                string emailPassword = request.EmailPassword;
                bool useSSL = request.UseSSL;
                string mailbox = request.Mailbox;

                Chilkat.Imap connectIMAP = new Chilkat.Imap();
                //  Anything unlocks the component and begins a fully-functional 30-day trial.
                success = connectIMAP.UnlockComponent("SOFTICIMAPMAILQ_hmgwtaxY2A2u");
                if (success != true)
                {
                    throw new Exception(connectIMAP.LastErrorText);
                }
                //  Connect to an IMAP server.
                //  Use TLS
                connectIMAP.Ssl = useSSL;
                connectIMAP.Port = serverPort;
                success = connectIMAP.Connect(serverName);
                if (success != true)
                {
                    throw new Exception(connectIMAP.LastErrorText);
                }
                //  Login
                success = connectIMAP.Login(emailAddress, emailPassword);
                if (success != true)
                {
                    throw new Exception(connectIMAP.LastErrorText);
                }
                //  Select an IMAP mailbox
                success = connectIMAP.SelectMailbox(mailbox);
                if (success != true)
                {
                    throw new Exception(connectIMAP.LastErrorText);
                }
                imap = connectIMAP;
            }
            catch (Exception error)
            {

            }
            return success;
        }
        public static EmailListResultModel GetEmails(IMAPConnectionRequestModel request)
        {
            EmailListResultModel result = new EmailListResultModel
            {
                NumberOfEmails = 0,
                Emails = new List<EmailItemResultModel>()
            };
            try
            {
                if (IMAPConnection(request))
                {
                    var emailCount = imap.NumMessages;
                    Chilkat.Email email = null;
                    var msgSet = imap.Search("ALL", true);
                    var bundle = imap.FetchHeaders(msgSet);
                    var cnt = bundle.MessageCount;

                    for (int i = 0; i <= cnt; i++)
                    {
                        //  Download the email by sequence number.
                        email = bundle.GetEmail(i);
                        if (email != null)
                        {
                            bool include = true;
                            if (include)
                            {
                                result.Emails.Add(
                                    new EmailItemResultModel
                                    {
                                        ImapUid = email.GetImapUid(),
                                        EmailDate = email.EmailDate.ToString("dd MMM yyyy HH:mm"),
                                        EmailSubject = email.Subject,
                                        FromName = email.FromName,
                                        FromAddress = email.FromAddress
                                    });
                            }
                        }
                    }
                    result.Emails.Reverse();
                    result.NumberOfEmails = emailCount;
                }
            }
            catch (Exception error)
            {

            }
            return result;
        }
        public static EmailBodyResultModel GetHTMLBodyAndReplaceImages(EmailBodyRequestModel request)
        {
            EmailBodyResultModel result = new EmailBodyResultModel
            {
                HTMLBody = ""
            };
            if (IMAPConnection(request))
            {
                if (!Directory.Exists(request.FilePath))
                {
                    Directory.CreateDirectory(request.FilePath);
                }
                string bodyText = imap.FetchSingle(request.ImapUid, true).GetHtmlBody();
                result.HTMLBody = replaceEmailImages(bodyText, request.FilePath, request.RootURL);
            }
            return result;
        }

        public static EmailBodyResultModel GetHTMLBody(EmailItemRequestModel request)
        {
            EmailBodyResultModel result = new EmailBodyResultModel
            {
                HTMLBody = ""
            };
            if (IMAPConnection(request))
            {
                string bodyText = imap.FetchSingle(request.ImapUid, true).GetHtmlBody();
                result.HTMLBody = bodyText;
            }
            return result;
        }

        public static EmailLinksResultModel GetEmailLinks(EmailItemRequestModel request)
        {
            EmailLinksResultModel result = new EmailLinksResultModel
            {
                EmailLinks = new List<EmailLinkItemResultModel>()
            };
            if (IMAPConnection(request))
            {
                string bodyText = imap.FetchSingle(request.ImapUid, true).GetHtmlBody();
                result.EmailLinks = getEmailLinks(bodyText);
            }
            return result;
        }

        public static EmailLinksResultModel GetEmailLinks(string bodyText)
        {
            EmailLinksResultModel result = new EmailLinksResultModel
            {
                EmailLinks = new List<EmailLinkItemResultModel>()
            };
            result.EmailLinks = getEmailLinks(bodyText);
            return result;
        }

        private static List<EmailLinkItemResultModel> getEmailLinks(string bodyText)
        {
            List<HtmlNode> aNodes = null;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(bodyText);
            aNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//a")
                          where node.Name == "a"
                          select node).ToList();
            List<EmailLinkItemResultModel> res = new List<EmailLinkItemResultModel>();
            foreach (HtmlNode node in aNodes)
            {
                var aLink = node.Attributes["href"].Value;
                var aLinkText = node.InnerText;
                var aLinkInnerHTML = node.InnerHtml;
                var check = res.Where(a => a.EmailLink.ToLower() == aLink.ToLower() && a.EmailLinkText.ToLower() == aLinkText.ToLower()).FirstOrDefault();
                if (check == null)
                {
                    res.Add(new EmailLinkItemResultModel
                    {
                        EmailLink = aLink,
                        EmailLinkText = aLinkText,
                        EmailLinkInnerHTML = aLinkInnerHTML
                    });
                }
            }
            return res;
        }

        public static string ReplaceEmailLinks(string bodyText, Dictionary<string, string> linkReplacements)
        {
            List<HtmlNode> aNodes = null;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(bodyText);
            aNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//a")
                      where node.Name == "a"
                      select node).ToList();
            List<EmailLinkItemResultModel> res = new List<EmailLinkItemResultModel>();
            foreach (HtmlNode node in aNodes)
            {
                var aLink = node.Attributes["href"].Value.ToLower();
                if (linkReplacements.ContainsKey(aLink))
                {
                    //find the link
                    if (linkReplacements[aLink] != null)
                    {
                        node.Attributes["href"].Value = linkReplacements[aLink];
                    }
                }
            }
            return doc.DocumentNode.OuterHtml;
        }

        public static EmailDeleteResultModel DeleteEmail(EmailItemRequestModel request)
        {
            EmailDeleteResultModel result = new EmailDeleteResultModel
            {
                EmailDeleted = false
            };
            if (IMAPConnection(request))
            {
                var ImapUid = request.ImapUid;
                Chilkat.Email email = imap.FetchSingle(ImapUid, true);

                result.EmailDeleted = imap.SetMailFlag(email, "Deleted", 1);
                if (result.EmailDeleted != true)
                {
                    throw new Exception(imap.LastErrorText);
                }
                result.EmailDeleted = imap.ExpungeAndClose();
                if (result.EmailDeleted != true)
                {
                    throw new Exception(imap.LastErrorText);
                }
            }
            return result;
        }

        private static string replaceEmailImages(string bodyText, string filePath, string rootURL)
        {
            List<HtmlNode> imageNodes = null;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(bodyText);
            imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//img")
                          where node.Name == "img"
                          select node).ToList();
            foreach (HtmlNode node in imageNodes)
            {
                var imageLink = node.Attributes["src"].Value;
                var guidFileName = downloadImage(imageLink, filePath);
                if (guidFileName != "")
                {
                    var newLink = rootURL;
                    if (!rootURL.EndsWith("/"))
                    {
                        rootURL += "/";
                    }
                    //rootURL += guidFileName;
                    node.Attributes["src"].Value = rootURL + guidFileName;
                }
            }
            return doc.DocumentNode.OuterHtml;
        }

        private static string downloadImage(string imageLink, string filePath)
        {
            //download the image
            using (WebClient wc = new WebClient())
            {
                byte[] fileBytes;
                try
                {
                    fileBytes = wc.DownloadData(imageLink);
                }
                catch (Exception err)
                {
                    throw new Exception(err.ToString());
                }

                string fileType = wc.ResponseHeaders[HttpResponseHeader.ContentType];
                string extension = "";
                if (fileType != null)
                {
                    switch (fileType)
                    {
                        case "image/jpeg":
                            extension = ".jpg";
                            break;
                        case "image/gif":
                            extension = ".gif";
                            break;
                        case "image/png":
                            extension = ".png";
                            break;
                        default:
                            break;
                    }
                    if (extension != "")
                    {
                        string GUIDFileName = Guid.NewGuid().ToString() + extension;
                        string localFileName = Path.Combine(filePath, GUIDFileName);
                        if (!Directory.Exists(Path.GetDirectoryName(localFileName)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(localFileName));
                        }
                        File.WriteAllBytes(localFileName, fileBytes);
                        return GUIDFileName;
                    }
                }
            }
            return "";
        }

    }
}
