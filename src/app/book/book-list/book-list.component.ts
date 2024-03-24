import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit{
  books : any = []

  constructor(private bookService : BookService){}

  ngOnInit(): void 
  {
   this.bookService.getBooks().subscribe(books => {
    this.books = books;

  })   
  }
}
