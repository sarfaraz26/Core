import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorListComponent } from './author/author-list/author-list.component';
import { AuthorFormComponent } from './author/author-form/author-form.component';
import { BookListComponent } from './book/book-list/book-list.component';
import { BookFormComponent } from './book/book-form/book-form.component';

const routes: Routes = [
  {path : '', component : AuthorListComponent},
  {path : 'api/authors', component : AuthorListComponent},
  {path : 'api/add/author', component : AuthorFormComponent},
  {path : 'api/books', component : BookListComponent},
  {path : 'api/add/book', component : BookFormComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
