import { Component, Inject } from '@angular/core';
import { Recipe } from '../models/Recipe';
import { Ingredient } from '../models/Ingredient';
import { HttpClient } from '@angular/common/http';
import { AuthorizeService } from '../../api-authorization/authorize.service';

@Component({
  selector: 'app-receitas',
  templateUrl: './receitas.component.html',
  styleUrls: ['./receitas.component.css']
})
export class ReceitasComponent {
  recipeData: Recipe = <Recipe>{};
  ingredientsData: Ingredient[] = [];
  //
  // TODO: arranjar forma de no html preencher o array de ingredientes ^^
  //
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, authorize: AuthorizeService) {
    authorize.getUser().subscribe((result: any) => {
      this.recipeData.userid = result.sub;
    });
  }

  submitForm() {
    // criar um ingrediente de teste ...
    this.ingredientsData.push(<Ingredient>{ name: "Teste", quantity: "Teste" });

    this.http.post<Recipe>(`${this.baseUrl}api/recipes`,this.recipeData).subscribe({
      next: (response) => {
        // percorrer todos os ingredientes
        (new Promise<void>(resolve => this.ingredientsData.forEach(async (value, idx, arr) => {
          value.recipeid = response.id;   // associar ingrediente a receita

          // criar ingrediente
          await this.http.post<Ingredient>(`${this.baseUrl}api/ingredients`, value).toPromise();

          if (idx == arr.length - 1) resolve();
        }))).then(() => alert("receita criada com sucesso"));
      },
      error: (response) => {
        console.error(response);
      }
    });
  }
}
