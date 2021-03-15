import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthServiceService } from '../auth-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formgroup: FormGroup;
  constructor(private authService: AuthServiceService) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm()
  {
    this.formgroup = new FormGroup({
      Username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    });
  }
  loginProces()
  {
    if (this.formgroup.valid)
    {
      this.authService.login(this.formgroup.value).subscribe(result => {
        if (result.Token) {
          console.log(result);
          alert(result.message);
        }
        else
        {
          alert(result.message);
        }
      })
    }
  }
}
