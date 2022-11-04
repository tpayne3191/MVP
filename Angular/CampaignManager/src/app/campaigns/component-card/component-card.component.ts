import { Component, EventEmitter, OnInit, Input, Output } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CampaignService } from 'src/app/services/campaign.service';
import Campaign from '../../types/campaign.model';
import {Operation} from '../../types/operation.model';



@Component({
  selector: 'app-component-card',
  templateUrl: './component-card.component.html',
  styleUrls: ['./component-card.component.css']
})
export class ComponentCardComponent implements OnInit {
  @Input() campaign: Campaign = {} as Campaign;
  editedCampaign: Campaign = {} as Campaign;
  campaigns$: Observable<Campaign[]> = new Observable<Campaign[]>();
  constructor(private campaignService: CampaignService) { }

  ngOnInit() {
    this.campaigns$ = this.campaignService.campaign$;

  }
  private mutateCampaigns = () => {
    this.campaigns$ = this.campaigns$.pipe(map((campaigns) => campaigns));
  }
  handleClicked([campaign, operation]: [Campaign, Operation]) {
    console.log(campaign);
    if (operation === 'edit') {
      this.editedCampaign = { ...campaign };
    } else if (operation === 'delete') {
      this.campaignService.delete(campaign).subscribe(() => {
        this.mutateCampaigns();
      });
    }
  }

  handleWeaponSubmit(campaign: Campaign) {
    if (campaign.id) {
      this.campaignService.update(campaign).subscribe(() => {
        this.mutateCampaigns();
      });
    } else {
      this.campaignService.create(campaign).subscribe(() => {
        this.mutateCampaigns();
      });
    }
  }

}
