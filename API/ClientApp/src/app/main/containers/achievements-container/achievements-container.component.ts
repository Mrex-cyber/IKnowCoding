import { Component, OnDestroy, OnInit } from '@angular/core';
import { IAchievement } from 'src/app/tests/models/IAchievement';
import { MainPageLoaderService } from '../../resources/main-page-loader.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-achievements-container',
  templateUrl: './achievements-container.component.html',
  styleUrls: ['./achievements-container.component.css']
})
export class AchievementsContainerComponent implements OnInit, OnDestroy {
  public achievements: IAchievement[] = [];

  private achievementsSubscription!: Subscription;

  constructor(private mainPageLoader: MainPageLoaderService) { }

  ngOnInit() {
    this.subscribeToApi();
  }

  ngOnDestroy (): void {
    this.achievementsSubscription.unsubscribe();
  }

  private subscribeToApi(){
    this.achievementsSubscription = this.mainPageLoader.getAchievements().subscribe(a => this.achievements = a);
  }
}
