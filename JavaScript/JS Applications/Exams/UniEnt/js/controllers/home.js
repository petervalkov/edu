import { getAll } from '../data.js';
import * as notifications from './notifications.js';

export async function getHome() {
    try {
        notifications.beginRequest();

        if (!this.app.userData.username) {
            this.partials = {
                header: await this.load('./templates/common/header.hbs'),
                footer: await this.load('./templates/common/footer.hbs')
            }

            this.partial('./templates/home.hbs', this.app.userData);
            notifications.endRequest();
        } else {
            const result = await getAll();

            if (result.hasOwnProperty('errorData')) {
                if (result.code === 3064) {
                    notifications.endRequest()
                    notifications.showInfo('Please login first');
                    this.redirect('#/login');
                    return;
                } else {
                    throw new Error(result.message);
                }
            }

            const context = Object.assign({ events: result }, this.app.userData);

            this.partials = {
                header: await this.load('./templates/common/header.hbs'),
                footer: await this.load('./templates/common/footer.hbs'),
                event: await this.load('./templates/event.hbs')
            }

            this.partial('./templates/events.hbs', context);
            notifications.endRequest();
        }
    } catch (e) {
        notifications.endRequest()
        notifications.showError(e.message);
    }
}