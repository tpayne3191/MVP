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
    const id: number = Number(this.route.snapshot.paramMap.get('id'));
    this.campaignsService.campaigns$.subscribe((campaigns) =>
    {
      this.charactersService.characters$.subscribe((characters) =>
      {
        this.campaign = campaigns.find((c) => c.id === id ) || {} as Campaign;
        this.characters = characters;
        let i = 0;
        for(i=this.characters.length-1;i >-1;i--)
        {
          if(this.characters[i].campaignId !== null){
            this.characters.splice(i,1);
          }
        }
       });
    });
    console.log('onInit', this.characters.length)
  }

  onFormSubmit(form: NgForm) {
    let charactersToEnroll: Character[] = form.controls['selectedCharacters'].value;

    console.log('onFormSubmit', charactersToEnroll)
    for(const characterAdd of charactersToEnroll)
    {
        characterAdd.campaignId = this.campaign.id;
        this.charactersService.update(characterAdd).subscribe(() => {
          this.mutateCharacters();
        });
    }
    this.goBack();
  }

  private mutateCharacters = () => {
    this.characters$ = this.characters$.pipe(map((characters) => characters));
  };

  resetForm(form: NgForm) {
    form.resetForm();
  }

  goBack(): void {
    window.location.reload();
    this.location.back();
  }
}
