import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { Author } from 'src/app/models/author/author.model';
import { AuthorService } from 'src/app/services/author/author.service';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css']
})
export class AuthorListComponent implements OnInit {

  authors : any = []

  constructor(private authorService : AuthorService, private router : Router){}

  ngOnInit(): void 
  {
    this.authorService.getAuthors().subscribe(authors => {
      this.authors = authors;    
    })  
  }

  PopulateRecord(record : Author)
  {
    this.authorService.authorForm = Object.assign({}, record);
    this.authorService.isSubmit = false;
    this.authorService.isDeleteVisible = true;
    this.router.navigate(['api/add/author'])
  }

}
