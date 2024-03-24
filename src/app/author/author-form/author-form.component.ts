import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Author } from 'src/app/models/author/author.model';
import { AuthorService } from 'src/app/services/author/author.service';


@Component({
  selector: 'app-author-form',
  templateUrl: './author-form.component.html',
  styleUrls: ['./author-form.component.css']
})
export class AuthorFormComponent implements OnDestroy{

  isVisible : boolean = false;

  constructor(public authorService : AuthorService, private router : Router){}

  submitRequest(form : NgForm)
  {
    if(this.authorService.authorForm.authorId > 0)
    {
       // Update request
       this.updateAuthor(form);
    }
    else
    {
       // add request 
       this.addAuthor(form);
    }

  }

  addAuthor(form : NgForm)
  {
    this.authorService.addAuthor().subscribe({
      next : res => {
        form.reset();
        this.authorService.toggleMsg = true; 
        this.isVisible = true;

        setTimeout(()=>{
          this.isVisible = false;
        }, 3000)
      },
      error : err => {
        console.log(err);
      }
    });
  }
  
  updateAuthor(form : NgForm)
  {
    this.authorService.updateAuthor().subscribe({
      next : res => {
        form.reset();
        this.authorService.isUpdateDivVisible = true;

        setTimeout(()=>{
          this.authorService.isUpdateDivVisible = false;
          this.router.navigate(['api/authors'])
        }, 3000)
      },
      error : err => {
        console.log();
      }
    })
  }

  deleteAuthor(form : NgForm)
  {
    this.authorService.deleteAuthor().subscribe({
      next : res => {
        form.reset();
        this.authorService.toggleMsg = false;
        this.isVisible = true;


        setTimeout(() => {
          this.isVisible = false;
          this.router.navigate(['api/authors'])
        }, 2000);
      },
      error : err => {
        console.log(err);
      }
    })
    
  }
  
  ngOnDestroy(): void {
    this.authorService.authorForm = new Author();
    this.authorService.isSubmit = true;
    this.authorService.isDeleteVisible = false;
  }
}
