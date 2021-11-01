export interface Pet {
    name: string,
    description: string,
    speciesId: number,
    dateOfBirth: Date
}

export interface PetDTO extends Pet {
    id: string;
    imageFileStorageId: string;
}

export interface PetItemDTO extends PetDTO {
    speciesName: string;
    age: number
}

export interface AddPetCommand extends Pet {
    image: string;
}

export interface UpdatePetCommand extends AddPetCommand {
    id: string;
}

