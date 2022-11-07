import { Component, EventEmitter, Input, Output } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CampaignService } from 'src/app/services/campaign.service';
import { Router } from '@angular/router';
import Campaign from '../../types/campaign.model';
import {Operation} from '../../types/operation.model';
import { AuthServiceService } from '../../services/auth-service.service';




@Component({
  selector: 'app-component-card',
  templateUrl: './component-card.component.html',
  styleUrls: ['./component-card.component.css']
})
export class ComponentCardComponent  {
  @Output() clicked: EventEmitter<[Campaign, Operation]> = new EventEmitter<[Campaign,Operation]>();
  @Input() campaign: Campaign = {} as Campaign;
  campaigns$: Observable<Campaign[]> = new Observable<Campaign[]>();
  editedCampaign: Campaign = {} as Campaign;
  Op = Operation;

  constructor(private campaignService: CampaignService,
    private authServiceService: AuthServiceService
    ) { }

  handleClick(campaign: Campaign, operation: Operation): void {
    this.clicked.emit([campaign, operation]);
  }


  ngOnInit() {
    this.campaigns$ = this.campaignService.campaigns$;

  }
  private mutateCampaigns = () => {
    this.campaigns$ = this.campaigns$.pipe(map((campaigns) => campaigns));
  }


  handleCampaignSubmit(campaign: Campaign) {
    if (campaign.id) {
      this.campaignService.update(campaign).subscribe(() => {
        this.mutateCampaigns();
      });
    } else {
      this.campaignService.create(campaign).subscribe(() => {
        this.mutateCampaigns();
      });
    }
    let emptyCampaign: Campaign = {} as Campaign;
    this.editedCampaign = {...emptyCampaign }
  }
  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }

}
