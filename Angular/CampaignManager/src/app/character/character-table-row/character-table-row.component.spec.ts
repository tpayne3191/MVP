import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacterTableRowComponent } from './character-table-row.component';

describe('CharacterTableRowComponent', () => {
  let component: CharacterTableRowComponent;
  let fixture: ComponentFixture<CharacterTableRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CharacterTableRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharacterTableRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
