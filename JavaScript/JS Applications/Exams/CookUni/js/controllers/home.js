import { getAll } from '../data.js';
import { showError } from './notifications.js';

export async function getHome(){
    try{
        if(!this.app.userData.username){
            this.partials = {  
                header: await this.load('./templates/common/header.hbs'),
                footer: await this.load('./templates/common/footer.hbs')
            }

            this.partial('./templates/home.hbs', this.app.userData);
        }else{
            let result = await getAll();

            if (result.hasOwnProperty('errorData')){ 
                throw new Error(result.message);
            }
            
            result = result.map(x => {
                x.ingredients = x.ingredients.split(',').map(x => x.trim());
                return x;
            });

            const context = Object.assign({ recipes: result }, this.app.userData);
            
            this.partials = {  
                header: await this.load('./templates/common/header.hbs'),
                footer: await this.load('./templates/common/footer.hbs'),
                recipe: await this.load('./templates/recipe.hbs')
            }

            this.partial('./templates/recipes.hbs', context);
        }  
    } catch(e) {
        showError(e.message);
    }
}