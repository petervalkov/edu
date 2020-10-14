import * as data from '../data.js';
import * as notifications from './notifications.js'

export async function getRegister() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    this.partial('./templates/users/register.hbs', this.app.userData);
}

export async function postRegister() {
    try {
        notifications.beginRequest();

        if (this.params.username.length < 3) { throw new Error('Username must be at least 3 characters!'); }
        if (this.params.password.length < 6) { throw new Error('Username must be at least 6 characters!'); }
        if (this.params.password !== this.params.rePassword) { throw new Error('Passwords don\'t match!'); }

        const result = await data.registerUser({
            username: this.params.username,
            password: this.params.password
        });

        if (result.hasOwnProperty('errorData')) { throw new Error(result.message); }

        const loginResult = await data.loginUser({
            login: this.params.username,
            password: this.params.password
        });

        setUserData.call(this, loginResult);

        notifications.endRequest()

        notifications.showInfo('User registration successful.');
        this.redirect('#/home');
    } catch (e) {
        notifications.endRequest()
        notifications.showError(e.message);
    }
}

export async function getLogin() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    this.partial('./templates/users/login.hbs', this.app.userData);
}

export async function postLogin() {
    try {
        notifications.beginRequest();
        const result = await data.loginUser({
            login: this.params.username,
            password: this.params.password
        });

        if (result.hasOwnProperty('errorData')) { throw new Error(result.message); }

        setUserData.call(this, result);
        notifications.endRequest();

        notifications.showInfo('Login successful.');
        this.redirect('#/home');
    } catch (e) {
        notifications.endRequest();
        notifications.showError(e.message);
    }
}

export async function logout() {
    try {
        notifications.beginRequest();
        const userToken = localStorage.getItem('userToken');

        const result = await data.logoutUser(userToken);

        if (result.hasOwnProperty('errorData')) { throw new Error(result.message); }

        clearUserData.call(this);

        notifications.endRequest();
        notifications.showInfo('Logout successful.');
        this.redirect('#/home');
    } catch (e) {
        notifications.endRequest();
        notifications.showError(e.message);
    }
}

function clearUserData() {
    localStorage.removeItem('userToken');
    localStorage.removeItem('username');
    localStorage.removeItem('userId');
    this.app.userData.username = '';
    this.app.userData.userId = '';
}

function setUserData(result) {
    localStorage.setItem('userToken', result['user-token']);
    localStorage.setItem('username', result.username);
    localStorage.setItem('userId', result.objectId);
    this.app.userData.username = result.username;
    this.app.userData.userId = result.objectId;
}