export interface AddAdvertisementCommand extends AdvertisementFormDTO { }

export interface UpdateAdvertisementCommand extends AddAdvertisementCommand {
    id: number;
}

export interface AdvertisementDTO {
    id: number;
    title: string;
    advertisementTypeId: number;
    startDate: Date;
    endDate: Date;
    cyclicalAssistanceFrequency: number;
}

export interface AdvertisementFormDTO {
    title: string;
    description: string;
    advertisementTypeId: number;
    petIds: number[];
    startDate: Date;
    endDate: Date;
    cyclicalAssistanceFrequency: number;
}
