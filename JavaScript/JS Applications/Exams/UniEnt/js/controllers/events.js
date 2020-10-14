import * as data from '../data.js'
import * as notifications from './notifications.js'

export async function getDetails() {
    try {
        notifications.beginRequest();

        const result = await data.getById(this.params.id);

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

        this.partials = {
            header: await this.load('./templates/common/header.hbs'),
            footer: await this.load('./templates/common/footer.hbs')
        }

        const displayEditDelete = this.app.userData.username === result.organizer;
        const context1 = Object.assign(result, this.app.userData);
        const context = Object.assign(context1, { displayEditDelete });

        this.partial('./templates/details.hbs', context);
        notifications.endRequest();
    } catch (e) {
        notifications.endRequest()
        notifications.showError(e.message);
    }
}

export async function getCreate() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    this.partial('./templates/create.hbs', this.app.userData);
}

export async function postCreate() {
    try {
        notifications.beginRequest();

        const entity = {
            name: this.params.name,
            dateTime: this.params.dateTime,
            description: this.params.description,
            imageURL: this.params.imageURL,
            organizer: this.app.userData.username,
            peopleInterestedIn: 0
        }

        const result = await data.create(entity);

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

        this.redirect(`#/details/${result.objectId}`);
        notifications.endRequest();
    } catch (e) {
        notifications.endRequest()
        notifications.showError(e.message);
    }
}

export async function getEdit() {
    try {
        notifications.beginRequest();
        const result = await data.getById(this.params.id);

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

        this.partials = {
            header: await this.load('./templates/common/header.hbs'),
            footer: await this.load('./templates/common/footer.hbs')
        }

        const display = this.app.userData.username === result.organizer ? 'block' : 'none';

        const context1 = Object.assign(result, this.app.userData);
        const context = Object.assign(context1, { display });

        this.partial('./templates/edit.hbs', context);
        notifications.endRequest();
    } catch (e) {
        notifications.endRequest()
        notifications.showError(e.message);
    }
}

export async function postEdit() {
    try {
        notifications.beginRequest();

        const entity = {
            objectId: this.params.id,
            name: this.params.name,
            dateTime: this.params.dateTime,
            description: this.params.description,
            imageURL: this.params.imageURL,
            peopleInterestedIn: Number(this.params.peopleInterestedIn)
        }

        const result = await data.edit(entity);

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

        this.redirect(`#/details/${result.objectId}`);
        notifications.endRequest();
    } catch (e) {
        notifications.endRequest()
        notifications.showError(e.message);
    }
}

export async function getDelete() {
    try {
        notifications.beginRequest();
        const result = await data.deleteEntity(this.params.id);

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

        this.redirect('#/home');
        notifications.endRequest();
    } catch (e) {
        notifications.endRequest()
        notifications.showError(e.message);
    }
}

export async function getJoin() {
    try {
        notifications.beginRequest();

        const eventToJoin = await data.getById(this.params.id);

        const entity = {
            objectId: this.params.id,
            peopleInterestedIn: Number(eventToJoin.peopleInterestedIn) + 1
        }

        const result = await data.edit(entity);

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

        this.redirect(`#/details/${result.objectId}`);
        notifications.endRequest();
    } catch (e) {
        notifications.endRequest()
        notifications.showError(e.message);
    }
}

export async function getProfile() {
    try {
        notifications.beginRequest();

        const result = await data.getEntityByOwnerId(this.app.userData.userId);
        const events = result.map(x => x.name);

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

        this.partials = {
            header: await this.load('./templates/common/header.hbs'),
            footer: await this.load('./templates/common/footer.hbs'),
        }

        const context1 = Object.assign({ events }, this.app.userData);
        const context = Object.assign(context1, { eventsCount: events.length });

        this.partial('./templates/users/profile.hbs', context);
        notifications.endRequest();
    } catch (e) {
        notifications.endRequest()
        notifications.showError(e.message);
    }
}