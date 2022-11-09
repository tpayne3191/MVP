import { Component, EventEmitter, Input, Output } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CampaignService } from 'src/app/services/campaign.service';
import { Router } from '@angular/router';
import Campaign from '../../types/campaign.model';
import { Operation } from '../../types/operation.model';
import { AuthServiceService } from '../../services/auth-service.service';

@Component({
  selector: 'app-component-card',
  templateUrl: './component-card.component.html',
  styleUrls: ['./component-card.component.css'],
})
export class ComponentCardComponent {
  campaigns$: Observable<Campaign[]> = new Observable<Campaign[]>();
  @Output() clicked: EventEmitter<[Campaign, Operation]> = new EventEmitter<
    [Campaign, Operation]
  >();
  @Input() campaign: Campaign = {} as Campaign;
  @Input() campaigns: Campaign[] = [] as Campaign[];
  editedCampaign: Campaign = {} as Campaign;
  Op = Operation;

  constructor(
    private campaignService: CampaignService,
    private authServiceService: AuthServiceService
  ) {}

  ngOnInit(): void {
    this.campaigns$ = this.campaignService.campaigns$;
  }

  handleClick(campaign: Campaign, operation: Operation): void {
    this.clicked.emit([campaign, operation]);
  }

  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }
}
