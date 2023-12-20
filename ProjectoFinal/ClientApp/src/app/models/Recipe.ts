import { Ingredient } from "./Ingredient"

export interface Recipe {
  id: string;
  name: string;
  description: string;
  title: string;
  difficulty: number;
  category: string;
  duration: number;
  userid: string;
  ingredients: Ingredient[];
}
