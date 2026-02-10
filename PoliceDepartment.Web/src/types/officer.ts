export interface BadgeNumberValue {
  value: string;
}

export interface BirthDateValue {
  value: string;
}

export interface PoliceOfficer {
  id: string;
  firstName: string;
  lastName: string;
  badgeNumber: BadgeNumberValue;
  birthDate: BirthDateValue;
  created: string;
  modified: string;
}

export interface CreateOfficerRequest {
  id: string;
  firstName: string;
  lastName: string;
  badgeNumber: string;
  birthDate: string;
}

export interface UpdateOfficerRequest {
  firstName: string;
  lastName: string;
  badgeNumber: string;
  birthDate: string;
}

export interface ApiError {
  type: string;
  title: string;
  status: number;
  detail: string;
}