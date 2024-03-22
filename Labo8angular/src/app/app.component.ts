import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Animal } from 'src/models/animal';
import { last, lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  // Inputs
  id?: number;
  type: string = "";
  name: string = "";

  animals: Animal[] = [];
  animal?: Animal;

  constructor(public http: HttpClient) { }

  // Récupère tous les animaux dans la base de données
  async getAnimals(): Promise<void> {
    let x = await lastValueFrom(this.http.get<Animal[]>("http://localhost:7256/api/Animals/GetAnimal"));
    console.log(x);
    this.animals = x;
  }

  // Ajoute un animal dans la base de données
  async postAnimal(): Promise<void> {
    // N
  }

  // Récupère un animal en particulier dans la base de données
  async getAnimal(): Promise<void> {
    let x = await lastValueFrom(this.http.get<Animal>("http://localhost:7256/api/Animals/GetAnimal/{id}"));
    console.log(x);
    this.animal = x;
  }

  // Modifie (ou crée) un animal en particulier dans la base de données
  async putAnimal(): Promise<void> {
    // M
  }

  // Supprime un animal en particulier dans la base de données
  async deleteAnimal(): Promise<void> {
    // A
  }

  // Sussy function
  async deleteAll(): Promise<void> {
    // L
  }

}
