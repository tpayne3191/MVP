import { Component, EventEmitter, OnInit, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { CampaignService } from 'src/app/services/campaign.service';
import Campaign from '../types/campaign.model';

@Component({
  selector: 'app-component-form',
  templateUrl: './component-form.component.html',
  styleUrls: ['./component-form.component.css']
})
export class ComponentFormComponent implements OnInit {
  @Output() campaignSubmitted: EventEmitter<Campaign> =
    new EventEmitter<Campaign>();

  @Input() campaignModel: Campaign = {} as Campaign;

  campaigns$: Observable<Campaign[]> = new Observable<Campaign[]>();

  constructor(private campaignService: CampaignService) { }

  ngOnInit() {
    this.campaigns$ = this.campaignService.campaign$;
  }

  handleSubmit() {
    this.campaignSubmitted.emit(this.campaignModel);
  }

}
