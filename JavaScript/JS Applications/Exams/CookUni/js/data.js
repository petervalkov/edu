import { startLoading, endLoading } from '../js/controllers/notifications.js';

const appSettings = {
    appId: '',
    restApiKey: ''
}

const endpoints = {
    'REGISTER': 'users/register',
    'LOGIN': 'users/login',
    'LOGOUT': 'users/logout',
    'ENTITY': 'data/recipes',
    'ENTITY_BY_OWNER': 'data/recipes?where=ownerId%3D\'',
}

function host(endpoint) {
    return `https://api.backendless.com/${appSettings.appId}/${appSettings.restApiKey}/${endpoint}`;
}

export async function registerUser(user){
    return handleRequest(endpoints.REGISTER, 'POST', user);
}

export async function loginUser(user){
    return handleRequest(endpoints.LOGIN, 'POST', user);
}

export async function logoutUser(){
    return await fetch(host(endpoints.LOGOUT), {
        headers: {
            'user-token': localStorage.getItem('userToken')
        }
    });
}

export async function create(entity){
    return handleRequest(endpoints.ENTITY, 'POST', entity);
}

export async function getAll(){
    return handleRequest(endpoints.ENTITY, 'GET');
}

export async function getById(id){
    return handleRequest(endpoints.ENTITY + '/' + id, 'GET');
}

export async function getEntityByOwnerId(id){
    return handleRequest(endpoints.ENTITY_BY_OWNER + id + '\'', 'GET');
}

export async function edit(entity){
    return handleRequest(endpoints.ENTITY, 'PUT', entity);
}

export async function deleteEntity(id){
    return handleRequest(endpoints.ENTITY + '/' + id, 'DELETE');
}

async function handleRequest(endpoint, method, data){
    startLoading();

    const options = { method }
    const headers = {
        'user-token': localStorage.getItem('userToken')
    }

    if(data !== undefined){
        headers['Content-Type'] = 'application/json'
        options.body = JSON.stringify(data);
    }

    options.headers = headers;

    const result = await (await fetch(host(endpoint), options)).json();

    endLoading();
    return result;
}