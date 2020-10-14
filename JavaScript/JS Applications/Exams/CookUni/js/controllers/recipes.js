import * as data from '../data.js'
import { showError, showInfo } from './notifications.js'

export async function getDetails() {
    try {
        const result = await data.getById(this.params.id);
        validateResult(result);
        
        const context = Object.assign(result, this.app.userData);
        context.ingredients = context.ingredients.split(',').map(x => x.trim());
        context.ownRecipe = this.app.userData.userId === result.ownerId;

        this.partials = {
            header: await this.load('./templates/common/header.hbs'),
            footer: await this.load('./templates/common/footer.hbs')
        }

        this.partial('./templates/details.hbs', context);
    } catch (e) {
        showError(e.message);
    }
}

export async function getCreate() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    this.partial('./templates/create.hbs', this.app.userData);
}

const catImages = {
    'Vegetables and legumes/beans': 'https://fyi.extension.wisc.edu/safefood/files/2019/04/CDC_produce.png',
    'Fruits': 'https://img1.mashed.com/img/uploads/2017/06/fruit-main.jpg',
    'Grain Food': 'https://www.merieuxnutrisciences.com/eu/sites/merieux_nutrisciences_en/files/styles/master_page_image/public/thumbnails/image/merieux_nutrisciences_cereals_grain_products_and_nuts.png',
    'Milk, cheese, eggs and alternatives': 'https://resize.hswstatic.com/w_1024/gif/different-cheeses.jpg',
    'Lean meats and poultry, fish and alternatives': 'https://media-cdn.tripadvisor.com/media/photo-s/15/dd/20/61/al-punto.jpg',
}

export async function postCreate() {
    try {
        if (this.params.meal.length < 4) { throw new Error('The meal should be at least 4 characters!'); }
        if (this.params.ingredients.length < 10) { throw new Error('There should at least 2 ingredients!'); }
        if (this.params.prepMethod.length < 10) { throw new Error('Preparation method should be at least 10 characters!'); }
        if (this.params.description.length < 10) { throw new Error('Description should be at least 10 characters!'); }
        
        const entity = {
            meal: this.params.meal,
            ingredients: this.params.ingredients,
            prepMethod: this.params.prepMethod,
            description: this.params.description,
            foodImageURL: this.params.foodImageURL,
            category: this.params.category,
            categoryImageURL: catImages[this.params.category],
            likesCounter: 0
        }

        const result = await data.create(entity);
        validateResult(result);

        showInfo('Recipe shared successfully!');
        this.redirect(`#/details/${result.objectId}`);
    } catch (e) {
        showError(e.message);
    }
}

export async function getEdit() {
    try {
        const result = await data.getById(this.params.id);
        validateResult(result);
        const context = Object.assign(result, this.app.userData);

        this.partials = {
            header: await this.load('./templates/common/header.hbs'),
            footer: await this.load('./templates/common/footer.hbs')
        }

        this.partial('./templates/edit.hbs', context);
    } catch (e) {
        showError(e.message);
    }
}

export async function postEdit() {
    try {
        const entity = {
            objectId: this.params.id,
            meal: this.params.meal,
            ingredients: this.params.ingredients,
            prepMethod: this.params.prepMethod,
            description: this.params.description,
            foodImageURL: this.params.foodImageURL,
            category: this.params.category,
            categoryImageURL: catImages[this.params.category],
        }

        const result = await data.edit(entity);
        validateResult(result);

        showInfo('Recipe edited successfully!');
        this.redirect(`#/details/${result.objectId}`);
    } catch (e) {
        showError(e.message);
    }
}

export async function getDelete(){
    try{
        const result = await data.deleteEntity(this.params.id);
        validateResult(result);

        showInfo("Your recipe was archived.");
        this.redirect('#/home');
    } catch(e) {
        showError(e.message);
    } 
}

export async function getLike() {
    try {
        const targetEntity = await data.getById(this.params.id);
        const entity = {
            objectId: this.params.id,
            likesCounter: Number(targetEntity.likesCounter) + 1
        }

        const result = await data.edit(entity);
        validateResult(result);

        showInfo('You liked that recipe.');
        this.redirect('#/home');
    } catch (e) {
        showError(e.message);
    }
}

function validateResult(result){
    if (result.hasOwnProperty('errorData')){ 
        throw new Error(result.message);
    }
}