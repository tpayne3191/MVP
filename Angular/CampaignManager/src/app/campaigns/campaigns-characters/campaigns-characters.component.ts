import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {  NgForm } from '@angular/forms'
import { map, Observable } from 'rxjs';
import { Location } from '@angular/common';
import Campaign from 'src/app/types/campaign.model';
import Character from 'src/app/types/character.model';
import { CharacterService } from 'src/app/services/character.service';
import { CampaignService } from 'src/app/services/campaign.service';

@Component({
  selector: 'app-campaigns-characters',
  templateUrl: './campaigns-characters.component.html',
  styleUrls: ['./campaigns-characters.component.css']
})
export class CampaignsCharactersComponent implements OnInit {
  characters$: Observable<Character[]> = new Observable<Character[]>();
  campaigns$: Observable<Campaign[]> = new Observable<Campaign[]>();
  editedCharacters: Character[] = [] as Character[];
  characters: Character [] = [] as Character[];
  campaign: Campaign = {} as Campaign;

  constructor(
    private charactersService: CharacterService,
    private campaignsService: CampaignService,
    private route: ActivatedRoute,
    private location: Location,
  ) {}

  ngOnInit(): void {
    const campaignId: number = 4;//Number(this.route.snapshot.paramMap.get('id'));
    this.charactersService.characters$.subscribe((characters) =>
    {
      this.characters = characters;

      let i = -1;
      for(const characterCheck of this.characters)
      {
        i++;
        if(!characterCheck.campaignId)
        {
          this.characters.splice(i,1);
        }
      }
    });
    console.log('onInit', this.characters)
  }

  onFormSubmit(form: NgForm) {
    let charactersToEnroll: Character[] = form.controls['selectedCharacters'].value;

    this.charactersService.characters$.subscribe(() =>
      {
        console.log('onFormSubmit', charactersToEnroll)
          for(const characterAdd of charactersToEnroll)
          {
            characterAdd.campaignId = this.campaign.id;
            console.log('onFormSubmit after for loop', characterAdd)
            this.charactersService.update(characterAdd).subscribe(() => {
              this.mutateProducts();
            });
          }
      });

    // this.location.back();
    //this.goBack();
  }

  private mutateProducts = () => {
    this.characters$ = this.characters$.pipe(map((characters) => characters));
    this.campaigns$ = this.campaigns$.pipe(map((campaigns) => campaigns));
  };

  resetForm(form: NgForm) {
    form.resetForm();
  }

  goBack(): void {
    this.location.back();
  }
}
