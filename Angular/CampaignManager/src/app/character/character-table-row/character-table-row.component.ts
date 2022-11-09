import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AuthServiceService } from 'src/app/services/auth-service.service';
import Character from 'src/app/types/character.model';
import { Operation } from 'src/app/types/operation.model';

@Component({
  selector: '[app-character-table-row]',
  templateUrl: './character-table-row.component.html',
  styleUrls: ['./character-table-row.component.css']
})
export class CharacterTableRowComponent {
  @Output() clicked: EventEmitter<[Character, Operation]> = new EventEmitter<[Character, Operation]>();
  @Input() character : Character = {} as Character;
  Op = Operation;

  constructor(private authServiceService: AuthServiceService) { }

  handleClick(operation: Operation): void {
    this.clicked.emit([this.character, operation]);
  }

  isLoggedIn() {
    return this.authServiceService.isLoggedIn();
  }
}
