import { Component, OnDestroy, OnInit } from '@angular/core';
import { IFeedback } from 'src/app/tests/models/IFeedback';
import { MainPageLoaderService } from '../../resources/main-page-loader.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-feedback-container',
  templateUrl: './feedback-container.component.html',
  styleUrls: ['./feedback-container.component.css']
})
export class FeedbackContainerComponent implements OnInit, OnDestroy {
  public feedbacks: IFeedback[] = [];

  private feedbacksSubscription!: Subscription;

  constructor(private mainPageLoader: MainPageLoaderService) { }

  ngOnInit(): void {
    this.subscribeToApi();
  }

  ngOnDestroy(): void {
    this.feedbacksSubscription.unsubscribe();
  }

  private subscribeToApi(){
    this.feedbacksSubscription = this.mainPageLoader.getFeedbacks().subscribe(f => this.feedbacks = f);
  }

  public scrollLeft() {
    const carousel = document.getElementById('carousel-container')!;
    carousel.scrollBy({
      left: 0,
      behavior: 'smooth'
    });
  }
  
  public scrollRight() {
    const carousel = document.getElementById('carousel-container')!;
    carousel.scrollBy({
      left: 1000,
      behavior: 'smooth'
    });
  }
}
