import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampaignsCharactersComponent } from './campaigns-characters.component';

describe('CampaignsCharactersComponent', () => {
  let component: CampaignsCharactersComponent;
  let fixture: ComponentFixture<CampaignsCharactersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CampaignsCharactersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CampaignsCharactersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
