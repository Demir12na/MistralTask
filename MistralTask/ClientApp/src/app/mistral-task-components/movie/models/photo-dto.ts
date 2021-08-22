export class PhotoDto {
    constructor(
        public image: string,
        public thumbImage: string,
        public alt: string,
        public title: string,
        public order: number
    ){}
}
