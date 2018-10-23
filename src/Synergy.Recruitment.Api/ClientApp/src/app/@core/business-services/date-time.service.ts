import { Injectable } from '@angular/core';

@Injectable()
export class DateTimeService {
  /**
   * Gets the time difference between two dates.
   * Gets the months, days, hours or minutes diff in the same order.
   * @param {Date} date1
   * @param {Date} date2
   * @returns
   * @memberof DateTimeService
   */
  public getTimeBetweenDates(date1, date2) {
    // Get 1 day in milliseconds
    const one_day = 1000 * 60 * 60 * 24;

    // Convert both dates to milliseconds
    const date1_ms = date1.getTime();
    const date2_ms = date2.getTime();

    // Calculate the difference in milliseconds
    let difference_ms = date2_ms - date1_ms;
    // take out milliseconds
    difference_ms = difference_ms / 1000;
    const seconds = Math.floor(difference_ms % 60);
    difference_ms = difference_ms / 60;
    const minutes = Math.floor(difference_ms % 60);
    difference_ms = difference_ms / 60;
    const hours = Math.floor(difference_ms % 24);
    const days = Math.floor(difference_ms / 24);

    if (days > 0) {
      return `${days}d`;
    } else if (hours > 0) {
      return `${hours}h`;
    } else if (minutes > 0) {
      return `${minutes}m`;
    }

    return `${seconds}s`;
  }
}
