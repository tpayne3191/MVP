import { Component, OnInit, Input, Output, EventEmitter, } from '@angular/core';
import {map, Observable } from 'rxjs';
import Campaign from '../types/campaign.model';
import { CampaignService } from '../services/campaign.service';
import { Operation } from '../types/operation.model';
import { Location } from '@angular/common';
import { AuthServiceService } from '../services/auth-service.service';

@Component({
  selector: 'app-campaign',
  templateUrl: './campaign.component.html',
  styleUrls: ['./campaign.component.css']
})
export class CampaignComponent implements OnInit {
  @Input() campaign: Campaign = {} as Campaign;
  editedCampaign: Campaign = {} as Campaign;
  campaigns$: Observable<Campaign[]> = new Observable<Campaign[]>();

  constructor(private campaignService: CampaignService,
    private location: Location,
    private authServiceService: AuthServiceService) { }

  ngOnInit() {
    this.campaigns$ = this.campaignService.campaigns$;

  }
  private mutateCampaigns = () => {
    this.campaigns$ = this.campaigns$.pipe(map((campaigns) => campaigns));
  }
  handleClicked([campaign, operation]: [Campaign, Operation]) {
    if (operation === 'edit') {
      this.editedCampaign = { ...campaign };
    } else if (operation === 'delete') {
    this.campaignService.delete(campaign).subscribe(() => {
        this.mutateCampaigns();
      });
    }
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
