import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerTableRowComponent } from './player-table-row.component';

describe('PlayerTableRowComponent', () => {
  let component: PlayerTableRowComponent;
  let fixture: ComponentFixture<PlayerTableRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlayerTableRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayerTableRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
