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
        if (this.params.username.length < 3) { throw new Error('Username must be at least 3 characters!'); }
        if (this.params.password.length < 6) { throw new Error('Username must be at least 6 characters!'); }
        if (this.params.password !== this.params.repeatPassword) { throw new Error('Passwords don\'t match!'); }

        const result = await data.registerUser({
            username: this.params.username,
            password: this.params.password,
            firstName: this.params.firstName,
            lastName: this.params.lastName
        });

        validateResult(result);

        const loginResult = await data.loginUser({
            login: this.params.username,
            password: this.params.password
        });

        validateResult(loginResult);
        setUserData.call(this, loginResult);
        
        notifications.showInfo('User registration successful.');
        this.redirect('#/home');
    } catch (e) {
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
        const result = await data.loginUser({
            login: this.params.username,
            password: this.params.password
        });

        validateResult(result);
        setUserData.call(this, result);

        notifications.showInfo('Login successful.');
        this.redirect('#/home');
    } catch (e) {
        notifications.showError(e.message);
    }
}

export async function logout() {
    try {
        const result = await data.logoutUser();
        validateResult(result);
        clearUserData.call(this);

        notifications.showInfo('Logout successful.');
        this.redirect('#/home');
    } catch (e) {
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
    localStorage.setItem('username', `${result.firstName} ${result.lastName}`);
    localStorage.setItem('userId', result.objectId);
    this.app.userData.username = `${result.firstName} ${result.lastName}`;
    this.app.userData.userId = result.objectId;
}

function validateResult(result){
    if (result.hasOwnProperty('errorData')){ 
        throw new Error(result.message);
    }
}