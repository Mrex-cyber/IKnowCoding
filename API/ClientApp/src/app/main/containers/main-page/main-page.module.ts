import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageComponent } from './main-page.component';
import { FeedbackCardComponent } from '../../components/feedback-card/feedback-card.component';
import { FeedbackContainerComponent } from '../feedback-container/feedback-container.component';
import { AchievementsContainerComponent } from '../achievements-container/achievements-container.component';
import { AchievementCardComponent } from '../../components/achievement-card/achievement-card.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [MainPageComponent,
    AchievementsContainerComponent,
    AchievementCardComponent,
    FeedbackContainerComponent,
    FeedbackCardComponent
  ]
})
export class MainPageModule { }
