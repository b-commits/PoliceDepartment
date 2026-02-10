import { useMutation, useQueryClient } from "@tanstack/react-query";
import type { UseMutationResult } from "@tanstack/react-query";
import { createOfficer } from "@/lib/api-client";
import type { PoliceOfficer, CreateOfficerRequest } from "@/types/officer";
import { OFFICERS_QUERY_KEY } from "./useOfficers";

export function useCreateOfficer(): UseMutationResult<
  PoliceOfficer,
  Error,
  CreateOfficerRequest
> {
  const queryClient = useQueryClient();

  return useMutation<PoliceOfficer, Error, CreateOfficerRequest>({
    mutationFn: (data: CreateOfficerRequest): Promise<PoliceOfficer> =>
      createOfficer(data),
    onSuccess: (): void => {
      void queryClient.invalidateQueries({ queryKey: OFFICERS_QUERY_KEY });
    },
  });
}