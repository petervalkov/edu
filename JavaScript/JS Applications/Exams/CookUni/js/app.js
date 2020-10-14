import { getHome } from './controllers/home.js';
import * as users from './controllers/users.js';
import * as events from './controllers/recipes.js';

window.addEventListener('load', async () => {
    const app = Sammy('#rooter', function(context) {
        this.use('Handlebars', 'hbs');

        this.userData = {
            username: localStorage.getItem('username') || '',
            userId: localStorage.getItem('userId') || '',
            userToken: localStorage.getItem('userToken') || ''
        };

        this.get('index.html', getHome);
        this.get('#/home', getHome);
        this.get('/', getHome);
        
        this.get('#/register', users.getRegister);
        this.post('#/register', (context) => { users.postRegister.call(context) });

        this.get('#/login', users.getLogin);
        this.post('#/login', (context) => { users.postLogin.call(context) });

        this.get('#/logout', users.logout);

        this.get('#/details/:id', events.getDetails);

        this.get('#/create', events.getCreate);
        this.post('#/create', (context) => { events.postCreate.call(context) });

        this.get('#/edit/:id', events.getEdit);
        this.post('#/edit/:id', (context) => { events.postEdit.call(context) });

        this.get('#/delete/:id', events.getDelete);
        
        this.get('#/like/:id', events.getLike);
    })

    app.run();
});