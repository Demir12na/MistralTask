export class MovieAddRatingReq {
    constructor(
        public star: number,
        public movieId: number
    ) { }
}
