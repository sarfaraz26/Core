import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from 'src/app/models/book/book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseURL : string = "http://localhost:12470/api/book" 

  constructor(private httpClient : HttpClient) { }

  getBooks() : Observable<Book[]>
  {
    return this.httpClient.get<Book[]>(this.baseURL)
  }
}
