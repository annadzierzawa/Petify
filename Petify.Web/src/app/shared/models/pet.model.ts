export interface Pet {
    name: string,
    description: string,
    speciesId: number,
    dateOfBirth: Date
}

export interface PetDTO extends Pet {
    id: number;
    imageFileStorageId: string;
}

export interface PetItemDTO extends PetDTO {
    speciesName: string;
    age: number;
    isChecked: boolean;
}

export interface AddPetCommand extends Pet {
    image: string;
}

export interface UpdatePetCommand extends AddPetCommand {
    id: string;
}

export enum AdvertisementTypes {
    Adoption = 1,
    CyclicalAssistance = 2,
    OneTimeHelp = 3,
    TemporaryAdoption = 4
}
