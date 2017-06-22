# FirebaseMessagingTest
Test app demonstrating Firebase Messaging iOS crash.

Steps to reproduce:
Open project in Unity v5.6.1f1
In Build Settings, set as iOS, and select Player Settings.
In Player Settings, set a bundle ID. 
- Make sure you can build to device with this bundle ID.
- Make sure no app already installed on the device shares this ID.
Build to iOS and open in XCode 8.3.2
Build to an iPhone 6 running iOS 10.3.1

On first run:
App will crash after initializing Firebase and attempting to read the device token used for notifications.

Subsequent runs:
the app will launch without crash.

Error stacktrace:
2017-06-22 11:18:51.189918-0400 ios[15035:4734451] -[UIApplication messaging:didRefreshRegistrationToken:]: unrecognized selector sent to instance 0x10340b1e0
2017-06-22 11:18:51.285474-0400 ios[15035:4734451] Uncaught exception: NSInvalidArgumentException: -[UIApplication messaging:didRefreshRegistrationToken:]: unrecognized selector sent to instance 0x10340b1e0
(
	0   CoreFoundation                      0x0000000192032ff0 <redacted> + 148
	1   libobjc.A.dylib                     0x0000000190a94538 objc_exception_throw + 56
	2   CoreFoundation                      0x0000000192039ef4 <redacted> + 0
	3   CoreFoundation                      0x0000000192036f4c <redacted> + 916
	4   CoreFoundation                      0x0000000191f32d2c _CF_forwarding_prep_0 + 92
	5   ios                                 0x0000000100b3a190 -[FIRMessaging defaultInstanceIDTokenWasRefreshed:] + 176
	6   CoreFoundation                      0x0000000191fcd5ec <redacted> + 20
	7   CoreFoundation                      0x0000000191fccd00 <redacted> + 400
	8   CoreFoundation                      0x0000000191fcca7c <redacted> + 60
	9   CoreFoundation                      0x000000019203b7a8 <redacted> + 1412
	10  CoreFoundation                      0x0000000191f1094c _CFXNotificationPost + 376
	11  Foundation                          0x0000000192a7b3e0 <redacted> + 676
	12  CoreFoundation                      0x0000000191fe09a0 <redacted> + 32
	13  CoreFoundation                      0x0000000191fde628 <redacted> + 372
	14  CoreFoundation                      0x0000000191fde96c <redacted> + 692
	15  CoreFoundation                      0x0000000191f0ed94 CFRunLoopRunSpecific + 424
	16  GraphicsServices                    0x0000000193978074 GSEventRunModal + 100
	17  UIKit                               0x00000001981c7130 UIApplicationMain + 208
	18  ios                                 0x00000001000c0ff4 main + 228
	19  libdyld.dylib                       0x0000000190f1d59c <redacted> + 4
)
2017-06-22 11:18:51.286422-0400 ios[15035:4734451] *** Terminating app due to uncaught exception 'NSInvalidArgumentException', reason: '-[UIApplication messaging:didRefreshRegistrationToken:]: unrecognized selector sent to instance 0x10340b1e0'
*** First throw call stack:
