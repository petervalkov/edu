const appSettings = {
    appId: '',
    restApiKey: ''
}

const endpoints = {
    'REGISTER': 'users/register',
    'LOGIN': 'users/login',
    'LOGOUT': 'users/logout',
    'ENTITY': 'data/events',
    'ENTITY_BY_OWNER': 'data/events?where=ownerId%3D\'',
}

function host(endpoint) {
    return `https://api.backendless.com/${appSettings.appId}/${appSettings.restApiKey}/${endpoint}`;
}

export async function registerUser(user) {
    return await (await fetch(host(endpoints.REGISTER), {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    })).json();
}

export async function loginUser(user) {
    return await (await fetch(host(endpoints.LOGIN), {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    })).json();
}

export async function logoutUser(userToken) {
    return await fetch(host(endpoints.LOGOUT), {
        headers: { 'user-token': userToken }
    });
}

export async function getAll() {
    return await (await fetch(host(endpoints.ENTITY), {
        headers: {
            'user-token': localStorage.getItem('userToken')
        }
    })).json();
}

export async function getById(id) {
    return await (await fetch(host(endpoints.ENTITY + '/' + id), {
        headers: {
            'user-token': localStorage.getItem('userToken')
        }
    })).json();
}

export async function create(entity) {
    return await (await fetch(host(endpoints.ENTITY), {
        method: 'POST',
        headers: {
            'user-token': localStorage.getItem('userToken'),
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(entity)
    })).json();
}

export async function edit(entity) {
    return await (await fetch(host(endpoints.ENTITY), {
        method: 'PUT',
        headers: {
            'user-token': localStorage.getItem('userToken'),
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(entity)
    })).json();
}

export async function deleteEntity(id) {
    return await (await fetch(host(endpoints.ENTITY + '/' + id), {
        method: 'DELETE',
        headers: {
            'user-token': localStorage.getItem('userToken')
        }
    })).json();
}

export async function getEntityByOwnerId(id) {
    return await (await fetch(host(endpoints.ENTITY_BY_OWNER + id + '\''), {
        headers: {
            'user-token': localStorage.getItem('userToken')
        }
    })).json();
}