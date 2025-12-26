# Add project specific ProGuard rules here.
# You can control the set of applied configuration files using the
# proguardFiles setting in build.gradle.

# Keep data classes
-keep class com.starpanel.app.data.model.** { *; }

# Keep WebSocket classes
-keep class okhttp3.** { *; }
-keep class okio.** { *; }

# Keep Moshi
-keep class com.squareup.moshi.** { *; }
-keep @com.squareup.moshi.JsonQualifier interface *

# Room
-keep class * extends androidx.room.RoomDatabase
-keep @androidx.room.Entity class *
