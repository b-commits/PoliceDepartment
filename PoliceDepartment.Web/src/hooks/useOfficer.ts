import { useQuery } from "@tanstack/react-query";
import type { UseQueryResult } from "@tanstack/react-query";
import { getOfficer } from "@/lib/api-client";
import type { PoliceOfficer } from "@/types/officer";

export function useOfficer(
  id: string | null
): UseQueryResult<PoliceOfficer, Error> {
  return useQuery<PoliceOfficer, Error>({
    queryKey: ["officers", id],
    queryFn: (): Promise<PoliceOfficer> => getOfficer(id!),
    enabled: id !== null,
  });
}