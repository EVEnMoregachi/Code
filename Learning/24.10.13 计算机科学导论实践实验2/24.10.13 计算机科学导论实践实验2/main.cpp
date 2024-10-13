#include <stdio.h>
#include <stdlib.h>
#include <cmath>
#include <windows.h>

double f(double x) {
    return 3.0 + 2.345 * x + 0.98372 * x * x + 0.3221 * x * x * x;
}

int main() {
    LARGE_INTEGER now, then, fr;
    double estimat = 0.0;// 积分值
    const int fre = 50000000;// 插样点数量
    double start = 0.0, end = 1.0;// 积分区间

    QueryPerformanceFrequency(&fr);

    for (int j = 0; j < 10; j++) { 
        int current_fre = fre * (j + 1) / 10;
        double delta = (end - start) / current_fre;

        QueryPerformanceCounter(&now);
        for (int i = 0; i < current_fre; i++) {
            estimat += abs(delta * (f(start + i * delta) + f(start + (i + 1) * delta)) / 2);
        }
        QueryPerformanceCounter(&then);

        printf("fer: %d samples: Area is %f.\n", current_fre, estimat);
        printf("CPU耗时：%f毫秒\n", (double)(then.QuadPart - now.QuadPart) * 1000 / (double)(fr.QuadPart));

        estimat = 0.0;
    }

    system("pause");
    return 0;
}


//#include <stdio.h>
//#include <stdlib.h>
//#include <math.h>
//#include <windows.h>
//#include"mpi.h"
//
//
//double f(double x) {
//    return 3.0 + 2.345 * x + 0.98372 * x * x + 0.3221 * x * x * x;
//}
//
//double Trap(double local_a, double local_b, int local_n, double h) {
//    double integral = (f(local_a) + f(local_b)) / 2.0;
//    for (int i = 1; i < local_n; i++) {
//        integral += f(local_a + i * h);
//    }
//    integral *= h;
//    return integral;
//}
//
//int main(int argc, char* argv[]) {
//    LARGE_INTEGER now, then, fr;
//    int myrank, nprocs;
//    QueryPerformanceFrequency(&fr);
//
//    double start = 0.0, end = 1.0; // 积分区间
//
//    MPI_Init(&argc, &argv);
//    MPI_Comm_rank(MPI_COMM_WORLD, &myrank);
//    MPI_Comm_size(MPI_COMM_WORLD, &nprocs);
//
//    for (int j = 0; j < 10; j++) { // 10种不同插样值
//        int fre = 50000000 * (j + 1) / 10; // 动态调整插样点数量
//        double h = (end - start) / fre;
//        int local_n = fre / nprocs;
//        double local_a = start + myrank * local_n * h;
//        double local_b = local_a + local_n * h;
//
//        QueryPerformanceCounter(&now);
//        double local_int = Trap(local_a, local_b, local_n, h);
//        double total_int;
//
//        if (myrank == 0) {
//            total_int = local_int;
//            double received_int;
//            for (int source = 1; source < nprocs; source++) {
//                MPI_Recv(&received_int, 1, MPI_DOUBLE, source, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
//                total_int += received_int;
//            }
//            QueryPerformanceCounter(&then);
//            printf("fer:%d samples: Area from %f to %f = %f\n", fre, start, end, total_int);
//            printf("MPI耗时：%f毫秒\n", (double)(then.QuadPart - now.QuadPart) * 1000 / (double)(fr.QuadPart));
//        }
//        else {
//            MPI_Send(&local_int, 1, MPI_DOUBLE, 0, 0, MPI_COMM_WORLD);
//        }
//    }
//
//    MPI_Finalize();
//    return 0;
//}
