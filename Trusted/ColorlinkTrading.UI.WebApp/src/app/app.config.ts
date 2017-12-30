import { ApiCommonProvider } from '../config/config.providers';
import { SdBaseService } from "../config/config.services";

export class AppConfig {

    public static readonly AUTH_LS_ADDRESS: string = '';
    public static readonly SERVICE_URL: string = '';

    public static readonly PROVIDERS = [
        ApiCommonProvider
    ];

    public static readonly SERVICES = [
        SdBaseService
    ];

    public static readonly APP_CONFIG = {
        mode: 'md',
        backButtonIcon: 'md-arrow-round-back',
    };

    public static readonly PAGES = [
        { title: 'Home', component: 'HomePage' },
        { title: 'Contact Us', component: 'ContactUsPage' },
        { title: 'Register', component: 'RegisterPage' },
        { title: 'Legal', component: 'LegalPage' },
    ];

    public static readonly STORAGE_CONFIG = {
        name: '__schoolDaysDb',
        driverOrder: ['indexeddb', 'sqlite', 'websql']
    };

}