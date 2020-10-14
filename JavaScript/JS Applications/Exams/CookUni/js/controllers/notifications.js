const elements = {
    loading: document.getElementById('loadingBox'),
    success: document.getElementById('successBox'),
    error: document.getElementById('errorBox'),
}

elements.success.addEventListener('click', hideInfo);
elements.error.addEventListener('click', hideError);

let requestsCount = 0;

export function startLoading(){
    requestsCount++;
    elements.loading.style.display = 'block';
}

export function endLoading(){
    requestsCount--;
    if(requestsCount === 0){
        elements.loading.style.display = 'none';
    }
}

export function showInfo(message){
    elements.success.textContent = message;
    elements.success.style.display = 'block';

    setTimeout(hideInfo, 3000);
}

export function hideInfo(){
    elements.success.style.display = 'none';
}

export function showError(message){
    elements.error.textContent = message;
    elements.error.style.display = 'block';
}

export function hideError(){
    elements.error.style.display = 'none';
}