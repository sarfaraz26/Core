import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Author } from 'src/app/models/author/author.model';

@Injectable({
  providedIn: 'root'
})

export class AuthorService {
  baseURL : string = "http://localhost:12470/api/author" 

  authorForm : Author = new Author();
  isSubmit : boolean = true;
  isDeleteVisible : boolean = false;
  toggleMsg : Boolean = false
  isUpdateDivVisible : Boolean = false;

  constructor(private httpClient : HttpClient) { }

  getAuthors() : Observable<Author[]>
  {
    return this.httpClient.get<Author[]>(this.baseURL)
  }

  addAuthor() : Observable<String>
  {
    return this.httpClient.post<String>(this.baseURL, this.authorForm);
  }

  deleteAuthor() : Observable<String>
  {
    return this.httpClient.delete<String>(`${this.baseURL}/${this.authorForm.authorId}`);
  }

  updateAuthor() : Observable<String>
  {
    return this.httpClient.put<String>(`${this.baseURL}/${this.authorForm.authorId}`, this.authorForm);
  }
}
