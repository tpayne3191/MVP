import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import Campaign from '../types/campaign.model';

@Injectable({
  providedIn: 'root'
})
export class CampaignService {

  constructor(private http: HttpClient) {}
  private url = 'https://localhost:5001/api/campaigns';

  // Load the initial data as an Observable
  campaign$: Observable<Campaign[]> = this.http.get<Campaign[]>(this.url);

  delete(campaign: Campaign): Observable<null> {
    return this.http.delete<null>(this.url + '/' + campaign.id);
  }

  update(campaign: Campaign): Observable<Campaign> {
    return this.http.put<Campaign>(this.url, campaign);
  }

  create(campaign: Campaign): Observable<Campaign> {
    return this.http.post<Campaign>(this.url, campaign);
  }
}
