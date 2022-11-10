import { Component, OnInit, Input } from '@angular/core';
import Campaign from 'src/app/types/campaign.model';
import { Observable } from 'rxjs';
import { AuthServiceService } from '../../services/auth-service.service';
import { CampaignService } from 'src/app/services/campaign.service';
import { map } from 'rxjs/operators';
import { Location } from '@angular/common';



@Component({
  selector: 'app-component-character-table',
  templateUrl: './component-character-table.component.html',
  styleUrls: ['./component-character-table.component.css']
})
export class ComponentCharacterTableComponent implements OnInit {

  @Input() campaign: Campaign = {} as Campaign;
  editedCampaign: Campaign = {} as Campaign;
  campaigns$: Observable<Campaign[]> = new Observable<Campaign[]>();


  constructor(
    private campaignService: CampaignService,
    private location: Location,
    private authServiceService: AuthServiceService
  ) { }

  ngOnInit(): void {
    this.campaigns$ = this.campaignService.campaigns$;
  }

  private mutatePlayers = () => {
    this.campaigns$ = this.campaigns$.pipe(map((campaigns) => campaigns));
  }

  goBack(): void {
    this.location.back();
  }

  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }
}
