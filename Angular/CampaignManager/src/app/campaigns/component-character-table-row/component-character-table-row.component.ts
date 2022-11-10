import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Operation } from '../../types/operation.model';
import { AuthServiceService } from '../../services/auth-service.service';
import Campaign from 'src/app/types/campaign.model';
import { Router } from '@angular/router';



@Component({
  selector: '[app-component-character-table-row]',
  templateUrl: './component-character-table-row.component.html',
  styleUrls: ['./component-character-table-row.component.css']
})
export class ComponentCharacterTableRowComponent {
  @Output() clicked: EventEmitter<[Campaign, Operation]> = new EventEmitter<[Campaign, Operation]>();
  @Input() campaign : Campaign = {} as Campaign;
  Op = Operation;

  constructor(
    private authServiceService: AuthServiceService,
    private router: Router
  ) { }

  handleClick(operation: Operation): void {
    this.clicked.emit([this.campaign, operation]);
  }

  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }
}
