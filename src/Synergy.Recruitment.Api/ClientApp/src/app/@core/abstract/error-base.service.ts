import { Observable } from 'rxjs';

export declare abstract class ErrorBaseService {
    abstract handleError (error: Response | any): Observable<never>;
}
