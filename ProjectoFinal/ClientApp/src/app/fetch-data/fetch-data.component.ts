import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthorizeService, IUser } from '../../api-authorization/authorize.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  forecasts: WeatherForecast[] = [];
  user: IUser | null = null;
  formData: WeatherForecast = <WeatherForecast>{};
  edit: boolean = false;

  private url: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, authorize: AuthorizeService) {
    this.url = baseUrl + 'weatherforecast';

    http.get<WeatherForecast[]>(this.url).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));

    // get info about authenticated user
    // user.sub -> it's the property of user id
    authorize.getUser().subscribe((result:any) => {
      this.user = result;
      console.log(result);

      this.http.get(`${baseUrl}api/user/${result.sub}`).subscribe({
        next: (response: any) => {
          console.log(response);
        }
      })
    });

    authorize.isAuthenticated().subscribe(authenticated => {
      if (authenticated) {
        console.log("authenticated");
        // TODO something if user is authenticated
      } else {
        console.log("not authenticated");
        // TODO something if user is not authenticated
      }
    });
  }

  submitForm() {
    // Process the form data here
   
    if (!this.edit) {
      console.log("new forecast", this.formData);

      this.http.post<WeatherForecast>(this.url, this.formData).subscribe({
        next: (response) => {
          console.log('Response from server:', response);
          this.forecasts.push(response);
        },
        error: (error) => {
          console.error('There was an error!', error);
        }
      });
    } else {
      console.log("update forecast", this.formData);

      this.http.put(`${this.url}/${this.formData.id}`, this.formData).subscribe({
        next: (response) => {
          console.log('Response from server:', response);
        },
        error: (error) => {
          console.error('There was an error!', error);
        }
      });
    }
  };
}

interface WeatherForecast {
  id: string;
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
