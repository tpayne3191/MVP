import { Component, OnInit } from '@angular/core';
import { CampaignService } from 'src/app/services/campaign.service';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import Campaign from 'src/app/types/campaign.model';

@Component({
  selector: 'app-component-details',
  templateUrl: './component-details.component.html',
  styleUrls: ['./component-details.component.css']
})
export class ComponentDetailsComponent implements OnInit {
  campaigns$: Observable<Campaign[]> = new Observable<Campaign[]>();
  campaign: Campaign = {} as Campaign
  constructor(
    private campaignService: CampaignService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.campaignService.campaign$.subscribe((campaigns) => {
      this.campaign = campaigns[id - 1];
  });

}

goBack(): void {
  this.location.back();
 }
}
