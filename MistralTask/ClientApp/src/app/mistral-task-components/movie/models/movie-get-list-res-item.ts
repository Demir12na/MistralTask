import { PhotoDto } from "./photo-dto";

export class MovieGetListResItem {
    constructor(
        public id: number,
        public name: string,
        public year: number,
        public rating: number,
        public totalStars: number,
        public fiveStars: number,
        public fourStars: number,
        public threeStars: number,
        public twoStars: number,
        public oneStars: number,
        public photos: Array<PhotoDto>
    ) { }
}
