export interface AddAdvertisementCommand {
    title: string;
    description: string;
    advertisementTypeId: number;
    petId: number;
    startDate: Date;
    endDate: Date;
    cyclicalAssistanceFrequency: number;
}
