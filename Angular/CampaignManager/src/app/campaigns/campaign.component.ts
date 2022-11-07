import { Component, OnInit, Input, Output, EventEmitter, } from '@angular/core';
import {map, Observable } from 'rxjs';
import { WeaponService } from '../services/weapon.service';
import Campaign from '../types/campaign.model';
import { CampaignService } from '../services/campaign.service';
import { Operation } from '../types/operation.model';


@Component({
  selector: 'app-campaign',
  templateUrl: './campaign.component.html',
  styleUrls: ['./campaign.component.css']
})
export class CampaignComponent implements OnInit {
  @Output() clicked: EventEmitter<[Campaign, Operation]> = new EventEmitter<[Campaign,Operation]>();
  @Input() campaign: Campaign = {} as Campaign;
  editedCampaign: Campaign = {} as Campaign;
  campaigns$: Observable<Campaign[]> = new Observable<Campaign[]>();

  constructor(private campaignService: CampaignService) { }

  ngOnInit() {
    this.campaigns$ = this.campaignService.campaigns$;

  }
  private mutateCampaigns = () => {
    this.campaigns$ = this.campaigns$.pipe(map((campaigns) => campaigns));
  }
  handleClicked([campaign, operation]: [Campaign, Operation]) {
    if (operation === 'edit') {
      this.editedCampaign = { ...campaign };
      console.log("editedCampaign =", this.editedCampaign.id);
    } else if (operation === 'delete') {
    this.campaignService.delete(campaign).subscribe(() => {
        this.mutateCampaigns();
      });
    }
  }

  // handleCampaignSubmit(campaign: Campaign) {
  //   if (campaign.id) {
  //     this.campaignService.update(campaign).subscribe(() => {
  //       this.mutateCampaigns();
  //     });
  //   } else {
  //     this.campaignService.create(campaign).subscribe(() => {
  //       this.mutateCampaigns();
  //     });
  //   }
  // }

}
